import cv2
import numpy as np
img=cv2.imread("9.png")
gri=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
ret,thresh=cv2.threshold(gri,75,200,cv2.THRESH_BINARY) #thresh eşik değer demek,hangi resm,eşik değerleri,binarye dönüştür
contur,hier=cv2.findContours(thresh,cv2.RETR_TREE,cv2.CHAIN_APPROX_SIMPLE) 
hull=[]
for i in range(len(contur)): #len kaç kontur noktası var
    hull.append(cv2.convexHull(contur[i],False)) #konturun indis numaralarını atar

z=np.zeros((thresh.shape[0],thresh.shape[1],3),np.uint8) # kontur ve hull değerlerini farklı bir pencerede çizmek için siyah tuval oluşturma ,görüntünün boyutlarını dödürecek,renkli olacak,dönüştürme işlemi
for i in range(len(contur)): #contur sayısı kadar oluştur
    cv2.drawContours(z,contur,i,[255,0,0],3,8,hier) #zemin üzerinde contur noktaları kadar,mavi,çizgi kalınlığı,kesintisiz çizgi
    cv2.drawContours(z,hull,i,(0,255,0),1,8)

cnt=hull[0] #sıfırıncı indisden geleni cnt içine atama
M=cv2.moments(cnt) #merkezini bulma
print(M)
alan=cv2.contourArea(cnt) #
print(alan)
print(M['m00'])#alanı verir m00
cevre=cv2.arcLength(cnt,True) #true şeklin açık yada kapalı olduğu anlamına gelir
print(cevre)

# cv2.imshow("resim",z)
# cv2.waitKey(0)
# cv2.destroyAllWindows()
