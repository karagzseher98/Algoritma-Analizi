import cv2

# Kedi resminin dosya yolu
image_path = "cat.png"

# Kedi tespiti için kullanılacak XML dosyasının dosya yolu
xml_path = "cat.xml"

# Resmi oku
image = cv2.imread(image_path)

# Gri tonlamaya dönüştür
gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

# Kedi tespiti için bir detektör oluştur
detector = cv2.CascadeClassifier(xml_path)

# Kedileri tespit et
rects = detector.detectMultiScale(gray, scaleFactor=1.045, minNeighbors=2)

# Tespit edilen kedilerin etrafına dikdörtgen çiz
for (i, (x, y, w, h)) in enumerate(rects):
    cv2.rectangle(image, (x, y), (x+w, y+h), (0, 255, 255), 2)
    cv2.putText(image, "Kedi {}".format(i+1), (x, y-10), cv2.FONT_HERSHEY_SIMPLEX, 0.55, (0, 255, 255), 2)

# Sonuçları göster
cv2.imshow("Kedi Tespiti", image)
cv2.waitKey(0)
