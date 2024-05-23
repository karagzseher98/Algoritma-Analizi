import cv2
import numpy as np
img=cv2.imread("6.png")
gri=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
gri=np.float32(gri) # float değere dönüştürmek gerekiyor
corner=cv2.goodFeaturesToTrack(gri,40,0.01,10) #hangi değişkeni alacak,kaç köşe yakalayacak,kalite değeri,köşeler arası mesafe pixel olara
corner=np.int0(corner)
for c in corner: #corner üzerinde gezme işlemi yapıp köşe yaklamaı için döngü açtı
   x,y =c.ravel()
   cv2.circle(img,(x,y),5,(255,0,0),-1)


cv2.imshow("u",img)
cv2.waitKey(0)
cv2.destroyAllWindows()