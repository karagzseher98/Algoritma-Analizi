import cv2

x = 1.1
y = 1.2

img = cv2.imread("16.png")
araba = cv2.CascadeClassifier("car.xml")

gri = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
cars = araba.detectMultiScale(gri, scaleFactor=x if x > y else y, minNeighbors=2)
for (x, y, w, h) in cars:
    cv2.rectangle(img, (x, y), (x+w, y+h), (255, 0, 0), 2)

cv2.imshow("1", img)
cv2.waitKey(0)
cv2.destroyAllWindows()

