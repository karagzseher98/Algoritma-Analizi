import cv2
img=cv2.imread("15.png")

vucut=cv2.CascadeClassifier("body.xml")
gri=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
bodies=vucut.detectMultiScale(gri,1.2,3) #ölçeklendirme önemli

for x,y,w,h in bodies:
    cv2.rectangle(img,(x,y),(x+w,y+h),(255,0,0),2)
cv2.imshow("1",img)
cv2.waitKey(0)
cv2.destroyAllWindows()