import aspose.ocr as ocr

# Initialize with Russian language
api = ocr.AsposeOcr()

# Or specify language explicitly
api = ocr.AsposeOcr()

# Create recognition settings with Russian
settings = ocr.RecognitionSettings()
settings.language = ocr.Language.RUS  # Указываем русский язык

# Load PDF
input = ocr.OcrInput(ocr.InputType.PDF)
input.add('resources/input/Изображение/004 (1).pdf')

# Recognize with Russian settings
result = api.recognize(input, settings)

# Print result
if result and len(result) > 0:
    print(result[0].recognition_text)
else:
    print("Не удалось распознать текст")