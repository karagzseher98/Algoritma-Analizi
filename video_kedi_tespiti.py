import cv2

# Kedi tespiti için kullanılacak XML dosyasının dosya yolu
xml_path = "cat.xml"

# Video dosyasının dosya yolu
video_path = "kedi.mp4"

# Kedi tespiti için bir detektör oluştur
detector = cv2.CascadeClassifier(xml_path)

# Video dosyasını aç
cap = cv2.VideoCapture(video_path)

# Video dosyasının başarıyla açıldığını kontrol et
if not cap.isOpened():
    print("Video dosyası açılamadı.")
    exit()

# Video dosyasının her bir karesini işle
while True:
    # Bir kareyi oku
    ret, frame = cap.read()

    # Eğer kare okunamadıysa veya video bittiğinde döngüyü kır
    if not ret:
        break

    # Gri tonlamaya dönüştür
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)

    # Kedileri tespit et
    rects = detector.detectMultiScale(gray, scaleFactor=1.045, minNeighbors=2)

    # Tespit edilen kedilerin etrafına dikdörtgen çiz
    for (i, (x, y, w, h)) in enumerate(rects):
        cv2.rectangle(frame, (x, y), (x+w, y+h), (0, 255, 255), 2)
        cv2.putText(frame, "Kedi {}".format(i+1), (x, y-10), cv2.FONT_HERSHEY_SIMPLEX, 0.55, (0, 255, 255), 2)

    # Sonuçları göster
    cv2.imshow('Kedi Tespiti', frame)

    # Çıkış için 'q' tuşuna basıldığında döngüyü kır
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

# Video dosyasını serbest bırak
cap.release()
# Tüm pencereleri kapat
cv2.destroyAllWindows()
