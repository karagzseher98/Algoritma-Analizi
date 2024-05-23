from ultralytics import YOLO
import cv2
import os

def process_frame(frame, model, classNames, human_output, animal_output):
    # Kareyi ayna görüntüsü olarak işle
    frame = cv2.flip(frame, 1)

    results = model(frame, stream=True)

    human_count = 0
    animal_count = 0

    for r in results:
        boxes = r.boxes

        for box in boxes:
            confidence = round(box.conf[0].item(), 2)
            cls = int(box.cls[0])
            class_name = classNames[cls]

            if confidence > 0.5:
                x1, y1, x2, y2 = map(int, box.xyxy[0])
                cv2.rectangle(frame, (x1, y1), (x2, y2), (255, 0, 255), 3)
                cv2.putText(frame, f'{class_name}: {confidence}', (x1, y1 - 10), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (255, 0, 0), 2)

                # İnsan algılandığında işlem yap
                if class_name == "person" and human_count < 4:
                    cv2.putText(frame, 'Insan Algilandi!', (x1, y1 - 30), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (0, 255, 0), 2)
                    human_img_path = os.path.join(human_output, f'human_{human_count}.png')
                    cv2.imwrite(human_img_path, frame, [cv2.IMWRITE_PNG_COMPRESSION, 0])
                    human_count += 1

                # Hayvan algılandığında işlem yap
                elif class_name in ["cat", "dog", "horse", "cow", "elephant", "bear", "zebra", "giraffe", "wolf", "fox", "pig"] and animal_count < 4:
                    cv2.putText(frame, 'Hayvan Algilandi!', (x1, y1 - 30), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (0, 0, 255), 2)
                    animal_img_path = os.path.join(animal_output, f'animal_{animal_count}.png')
                    cv2.imwrite(animal_img_path, frame, [cv2.IMWRITE_PNG_COMPRESSION, 0])
                    animal_count += 1

    return frame

def main():
    cap = cv2.VideoCapture(0)
    cap.set(3, 640)
    cap.set(4, 480)

    model = YOLO("yolov8n.pt")

    classNames = ["person", "bicycle", "car", "motorbike", "aeroplane", "bus", "train", "truck", "boat",
                  "traffic light", "fire hydrant", "stop sign", "parking meter", "bench", "bird", "cat",
                  "dog", "horse", "sheep", "cow", "elephant", "bear", "zebra", "giraffe", "backpack", "umbrella",
                  "handbag", "tie", "suitcase", "frisbee", "skis", "snowboard", "sports ball", "kite", "baseball bat",
                  "baseball glove", "skateboard", "surfboard", "tennis racket", "bottle", "wine glass", "cup",
                  "fork", "knife", "spoon", "bowl", "banana", "apple", "sandwich", "orange", "broccoli",
                  "carrot", "hot dog", "pizza", "donut", "cake", "chair", "sofa", "pottedplant", "bed",
                  "diningtable", "toilet", "tvmonitor", "laptop", "mouse", "remote", "keyboard", "cell phone",
                  "microwave", "oven", "toaster", "sink", "refrigerator", "book", "clock", "vase", "scissors",
                  "teddy bear", "hair drier", "toothbrush",
                  "wolf", "fox", "pig"
                  ]

    output_folder = os.path.join(os.path.expanduser('~'), 'OneDrive', 'Belgeler', 'GitHub', 'BMO_odevler_2022', 'seherkaragoz_odev2')
    human_output = os.path.join(output_folder, 'insan')
    animal_output = os.path.join(output_folder, 'hayvan')

    os.makedirs(human_output, exist_ok=True)
    os.makedirs(animal_output, exist_ok=True)

    while True:
        success, frame = cap.read()

        if not success:
            print("Could not read frame")
            break

        processed_frame = process_frame(frame, model, classNames, human_output, animal_output)
        cv2.imshow('Webcam', processed_frame)

        if cv2.waitKey(1) == ord('q'):
            break

    cap.release()
    cv2.destroyAllWindows()

if __name__ == "__main__":
    main()
