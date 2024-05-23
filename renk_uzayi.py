import cv2
import numpy as np
img=cv2.imread("baykus.jpg")
img1=cv2.cvtColor(img,cv2.COLOR_BGR2RGB)#renk dönüştürme kodu
img2=cv2.cvtColor(img,cv2.COLOR_BGR2HSV)
img3=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)#gri tonlama için
cv2.imshow("kus",img)
cv2.imshow("rgb",img1)
cv2.imshow("hsv",img2)
cv2.imshow("gray",img3)
cv2.waitKey(0)
cv2.destroyAllWindows()