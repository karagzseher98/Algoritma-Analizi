import cv2
import numpy as np
img=cv2.imread("9.png")
gri=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
ret,thresh=cv2.threshold(gri,75,200,cv2.THRESH_BINARY) #thresh eşik değer demek,hangi resm,eşik değerleri,binarye dönüştür
contur,h=cv2.findContours(thresh,cv2.RETR_TREE,cv2.CHAIN_APPROX_SIMPLE) 
h=list() #konveks noktaların saklanması için liste oluştrup kontur içerisinden bulma
for i in range(len(contur)): #len kaç kontur noktası var
    h.append(cv2.convexHull(contur[i],False)) #konturun indis numaralarını atar
z=np.zeros((thresh.shape[0],thresh.shape[1],3),np.uint8) # kontur ve hull değerlerini farklı bir pencerede çizmek için siyah tuval oluşturma ,görüntünün boyutlarını dödürecek,renkli olacak,dönüştürme işlemi
for i in range(len(contur)): #contur sayısı kadar oluştur
    cv2.drawContours(z,contur,i,[255,0,0],3,8) #zemin üzerinde contur noktaları kadar,mavi,çizgi kalınlığı,kesintisiz çizgi
    cv2.drawContours(z,h,i,(0,255,0),1,8)


cv2.imshow("resim",z)
cv2.waitKey(0)
cv2.destroyAllWindows()
