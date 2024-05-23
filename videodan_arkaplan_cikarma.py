import cv2
import numpy as np
img=cv2.imread("10.png")
font=cv2.FONT_HERSHEY_COMPLEX
gri=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
a,thresh=cv2.threshold(gri,200,300,cv2.THRESH_BINARY)
contur,b=cv2.findContours(thresh,cv2.RETR_TREE,cv2.CHAIN_APPROX_SIMPLE)
for i in contur: # konturleri yaklaştırma detaylandırma işlemi approx(yaklaştırma)
    e=0.01*cv2.arcLength(i,True) #true açık mı kapalı mı 
    approx=cv2.approxPolyDP(i,e,True) #gelen kontur değeri,epsilon değeri
    cv2.drawContours(img,[approx],0,5) #img üzerinden aprox noktalarını,sonuncu rengi
    x=approx.ravel()[0] #her şekil için x ve y değeri sıfırı x e eşitledi
    y=approx.ravel()[1]
    print(approx)
    print(len(approx))
    if len(approx)==3: #şekil aldılama 
        cv2.putText(img,"ucgen",(x,y),font,1,1,(0))
    elif len(approx)==4:
        cv2.putText(img,"dortgen",(x,y),font,1,1,(0))
    elif len(approx)==5:
        cv2.putText(img,"besgen",(x,y),font,1,1,(0))
    elif len(approx)==6:
        cv2.putText(img,"altigen",(x,y),font,1,1,(0))    
    else :
        cv2.putText(img,"daire",(x,y),font,1,1,(0))
cv2.imshow("a",img)
cv2.waitKey(0)
cv2.destroyAllWindows()