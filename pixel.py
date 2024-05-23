import cv2
import numpy as np
img=cv2.imread("baykus.jpg")
renk=img[200,300]
print(renk)
#print(img.shape)#boyut bilgisi veriyor
# mavi=img[200,300,0]
# print("mavi",mavi)
# yesil=img[200,300,1]
# print("yesil",yesil)
# kirmizi=img[200,300,2]
# print("kirmizi",kirmizi)
img[200,300,0]=0
print(img[200,300])
mavi=img.item(150,150,0)#maviye o pixseldeki değeri atadı
print(mavi)
img.itemset((150,150,0),200)#150 pixsel değeri 0 mavi 200 onun yerine atanacak değer
print(img[150,150])
cv2.imshow("kus",img)
cv2.waitKey(0)
cv2.destroyAllWindows()