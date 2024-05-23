import cv2
import numpy as np
cap=cv2.VideoCapture(0)
while True:
    ret,frame=cap.read()
    frame=cv2.flip(frame,1) #ters çevirme işlemi
    kenar=cv2.Canny(frame,200,300) #yakalaması istenen kenar sayısı
    cv2.imshow("0",frame)
    cv2.imshow("c",kenar)
    if cv2.waitKey(10)& 0xFF==ord("q"):
     break 

cap.release()
cv2.destroyAllWindows()
    