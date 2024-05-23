import cv2
import numpy as np

# İlk görüntüyü "4.png" dosyasından oku
img1 = cv2.imread("4.png")

# İkinci görüntüyü "5.png" dosyasından oku
img2 = cv2.imread("5.png")

# Görüntülerin boyutları aynı olmalı, farklı boyutlarda ise birini diğerine uygun boyuta getir
img2 = cv2.resize(img2, (img1.shape[1], img1.shape[0]))

# İki görüntü üzerinde bitwise AND işlemi gerçekleştir
# bit_and = cv2.bitwise_and(img1, img2)
# bit_or = cv2.bitwise_or(img1, img2)
# bit_xor=cv2.bitwise_xor(img1,img2)
bit_not1=cv2.bitwise_not(img1,img2)
bit_not2=cv2.bitwise_not(img2,img1)

# Görüntüleri ekranda göster
cv2.imshow("Birinci Görüntü", img1)
cv2.imshow("İkinci Görüntü", img2)
# cv2.imshow("AND Sonucu", bit_and)
# cv2.imshow("or", bit_or)
# cv2.imshow("or", bit_xor)
cv2.imshow("not1", bit_not1)
cv2.imshow("not2", bit_not2)


# Bir tuşa basılmasını bekleyip, ekrandaki pencereleri kapat
cv2.waitKey(0)
cv2.destroyAllWindows()
