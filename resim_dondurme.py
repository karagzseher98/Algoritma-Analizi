import cv2
import numpy as np
img=cv2.imread("baykus.jpg",0) # 0 siyah beyaz yaptı
sat,sut=img.shape
m=cv2.getRotationMatrix2D((sut/2,sat/2),90,2) #90 saat yönünde 1 ölçeklik 

d=cv2.warpAffine(img,m,(sat,sut))


cv2.imshow("resim",d)
cv2.waitKey(0)
cv2.destroyAllWindows()