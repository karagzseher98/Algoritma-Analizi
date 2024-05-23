import cv2
import numpy as np
img=cv2.imread("7.png")
gri=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
ret,thres=cv2.threshold(gri,100,200,cv2.THRESH_BINARY)  #sıfır ve bir sistemine döndü sıfırlar siyah 1 ler beyazı ifade ediyor
cont,a=cv2.findContours(thres,cv2.RETR_TREE,cv2.CHAIN_APPROX_SIMPLE)  #çizgilerin koordinatını belirleme
#print(cont)
cv2.drawContours(img,cont,-1,(0,255,0),2) #sıfır sağ taraftaki konturları verdi 1 sol taraftaki -1 hepsini verir
cv2.imshow("1",img)
cv2.waitKey(0)
cv2.destroyAllWindows()
