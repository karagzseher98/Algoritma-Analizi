import cv2
import numpy as np
img1=cv2.imread("1.png")
img2=cv2.imread("2.png")
img3=cv2.imread("3.png")
blr=cv2.blur(img1,(5,5))
gb=cv2.GaussianBlur(img1,(5,5),cv2.BORDER_DEFAULT) # sadece tek sayıları alır borederdefault kenar için
mb=cv2.medianBlur(img3,3) # tek sayı gerekiyor
b=cv2.bilateralFilter(img2,9,25,25)

cv2.imshow("orj",img2)
cv2.imshow("b",b)

# cv2.imshow("orj",img3)
# cv2.imshow("mb",mb)
# cv2.imshow("b",blr)
# cv2.imshow("gb",gb)

cv2.waitKey(0)
cv2.destroyAllWindows()
  