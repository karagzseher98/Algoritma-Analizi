from ultralytics import YOLO
import cv2
import os
import pygame

def process_frame(frame, model, classNames):
    frame = cv2.flip(frame, 1)
    results = model(frame, stream=True)
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
                if class_name == "person":
                    play_sound("human_detected.wav")
                elif class_name in ["cat", "dog", "horse", "cow", "elephant", "bear", "zebra", "giraffe", "wolf", "fox", "pig"]:
                    play_sound("animal_detected.wav")
    return frame

def play_sound(sound_file):
    pygame.mixer.init()
    pygame.mixer.music.load(sound_file)
    pygame.mixer.music.play()

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
    while True:
        success, frame = cap.read()
        if not success:
            print("Could not read frame")
            break
        processed_frame = process_frame(frame, model, classNames)
        cv2.imshow('Webcam', processed_frame)
        if cv2.waitKey(1) == ord('q'):
            break
    cap.release()
    cv2.destroyAllWindows()

if __name__ == "__main__":
    main()
