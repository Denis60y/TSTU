#include <iostream>
#include <windows.h>
#include <clocale>


using namespace std;

int main()
{
    SetConsoleCP(65001);
    SetConsoleOutputCP(65001);

    const wchar_t* filename = L"OS_lab2.txt";

    HANDLE hFile = CreateFile(
        filename,
        GENERIC_READ | GENERIC_WRITE,
        0,                             
        NULL,
        OPEN_EXISTING,                 
        FILE_ATTRIBUTE_NORMAL,
        NULL
    );

    if (hFile == INVALID_HANDLE_VALUE) {
        std::cerr << "Ошибка открытия файла! Код ошибки: " << GetLastError() << std::endl;
        return 1;
    }

    std::cout << "Файл открыт. Дескриптор файла (hFile): " << hFile << std::endl;

    DWORD fileSize = GetFileSize(hFile, NULL);
    if (fileSize == INVALID_FILE_SIZE) {
        std::cerr << "Ошибка получения размера файла!" << std::endl;
        CloseHandle(hFile);
        return 1;
    }
    std::cout << "Размер файла: " << fileSize << " байт." << std::endl;

    if (fileSize == 0) {
        std::cerr << "Файл пуст! Добавьте текст в файл перед запуском." << std::endl;
        CloseHandle(hFile);
        return 1;
    }

    HANDLE hMapping = CreateFileMapping(
        hFile,
        NULL,
        PAGE_READWRITE,                
        0,
        0,                             
        NULL
    );

    if (hMapping == NULL) {
        std::cerr << "Ошибка CreateFileMapping! Код ошибки: " << GetLastError() << std::endl;
        CloseHandle(hFile);
        return 1;
    }
    std::cout << "Создан объект File-mapping. Дескриптор (hMapping): " << hMapping << std::endl;

    LPVOID pBuffer = MapViewOfFile(
        hMapping,
        FILE_MAP_ALL_ACCESS,           
        0,
        0,
        0                              
    );

    if (pBuffer == NULL) {
        std::cerr << "Ошибка MapViewOfFile! Код ошибки: " << GetLastError() << std::endl;
        CloseHandle(hMapping);
        CloseHandle(hFile);
        return 1;
    }
    std::cout << "Файл спроецирован в память. Базовый адрес: " << pBuffer << std::endl;

    char* localData = new char[fileSize + 1];
    CopyMemory(localData, pBuffer, fileSize);
    localData[fileSize] = '\0';

    std::cout << "\n--- Содержимое файла ---\n" << localData << "\n------------------------\n" << std::endl;

    int russianCount = 0;
    int latinCount = 0;

    for (DWORD i = 0; i < fileSize; i++) {
        unsigned char c = localData[i];

        if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')) {
            latinCount++;
        }

        else if ((c >= 192 && c <= 255) || c == 168 || c == 184) {
            russianCount++;
        }
    }

    std::cout << "Результаты анализа текста:" << std::endl;
    std::cout << "Латинских букв: " << latinCount << std::endl;
    std::cout << "Русских букв: " << russianCount << std::endl;

    delete[] localData;
    UnmapViewOfFile(pBuffer);
    CloseHandle(hMapping);
    CloseHandle(hFile);
    return 0;
}

