import cv2

img=cv2.imread("14.png")
yuz=cv2.CascadeClassifier("frontal.xml")
gri=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
faces=yuz.detectMultiScale(gri,1.3,4) #dört değişken dönderiyor yüzün boutlarını genişliği yüksekliği

for x,y,w,h in faces:
    cv2.rectangle(img,(x,y),(x+w,y+h),(255,0,0),2)
cv2.imshow("1",img)
cv2.waitKey(0)
cv2.destroyAllWindows()
