import cv2
import numpy as np

img=cv2.imread("11.png")

gri=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
kenar=cv2.Canny(gri,100,250)
cizgi=cv2.HoughLinesP(kenar,1,np.pi/180,50) #cizgi belirleme
print(cizgi)
for i in cizgi: #çizgi yakalamak için koordinat alıyor

    x1,y1,x2,y2=i[0]
    cv2.line(img,(x1,y1),(x2,y2),(255,0,0),5) #koordinatlar üzerinde çizim yap


cv2.imshow("a",img)
cv2.waitKey(0)

