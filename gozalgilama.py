import cv2
img=cv2.imread("14.png")
yuz=cv2.CascadeClassifier("frontal.xml")
goz=cv2.CascadeClassifier("eye.xml")
gri=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
faces=yuz.detectMultiScale(gri,1.3,4) #gri resim üstünde 1.3 ölçekli 4 kutucul yakalayacak

for x,y,w,h in faces:
    cv2.rectangle(img,(x,y),(x+w,y+h),(255,0,0),2) #yüzü algılayıp kutu içine alacak

    img2=img[y:y+h,x:x+h] #yüz kısmını algıladığı yeri  bu değişken içine atayacak
    
    gri2=gri[y:y+h,x:x+h] #ayn işlemi gri için yapacak gri üzerinde çalışacak 
    gozler=goz.detectMultiScale(gri2) 

    for x1,y1,w1,h1 in gozler:
        cv2.rectangle(img2,(x1,y1),(x1+w1,y1+h1),(0,0,255),2) # gozler için kutucuk içine alma işlemi yapıyor
cv2.imshow("1",img)
cv2.waitKey(0)
cv2.destroyAllWindows()
