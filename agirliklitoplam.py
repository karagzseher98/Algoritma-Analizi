import cv2
import numpy as np
daire=np.zeros((512,512,3),np.uint8)+255
cv2.circle(daire,(256,256),50,(255,0,0),-1)

kare=np.zeros((512,512,3),np.uint8)+255
cv2.rectangle(kare,(150,150),(350,350),(0,255,0),-1)

agirlik=cv2.addWeighted(daire,0.5,kare,0.5,0)#renk tonu ağırlığına göre alıyor

cv2.imshow("ağırlık",agirlik)
cv2.waitKey(0)
cv2.destroyAllWindows()