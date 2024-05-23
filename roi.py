import cv2
import numpy as np
#sadece ilgili alanda işlem yapıyor tüm alanda işlem yapmıyor
img=cv2.imread("baykus.jpg")
roi=img[100:350,150:250]#istediğim pixsel aralığını gösteriyor
cv2.imshow("resim",img)
cv2.imshow("roi",roi)
cv2.waitKey(0)
cv2.destroyAllWindows()