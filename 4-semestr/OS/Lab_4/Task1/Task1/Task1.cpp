#undef UNICODE
#undef _UNICODE

#include <iostream>
#include <windows.h>
#include <tlhelp32.h> 

using namespace std;

void Task1_Modules() {
    cout << "--- ЗАДАНИЕ 1: ИНФОРМАЦИЯ О МОДУЛЯХ ---" << endl;

    char path[MAX_PATH];

    // 1. Для текущей программы (передаем NULL, чтобы получить дескриптор текущего процесса)
    HMODULE hCurrent = GetModuleHandle(NULL);
    GetModuleFileName(hCurrent, path, MAX_PATH); // Получаем полный путь

    cout << "ТЕКУЩАЯ ПРОГРАММА:" << endl;
    cout << " Дескриптор: " << hCurrent << endl;
    cout << " Путь: " << path << endl;

    // 2. Для известной библиотеки (например, системной kernel32.dll)
    HMODULE hLibrary = GetModuleHandle("kernel32.dll");
    if (hLibrary != NULL) {
        GetModuleFileName(hLibrary, path, MAX_PATH);
        cout << "\nБИБЛИОТЕКА kernel32.dll:" << endl;
        cout << " Дескриптор: " << hLibrary << endl;
        cout << " Путь: " << path << endl;
    }
    cout << endl;
}

// =====================================================================
// ЗАДАНИЕ 2: Работа с дескрипторами процессов по шагам
// =====================================================================
void Task2_ProcessHandles() {
    cout << "--- ЗАДАНИЕ 2: ШАГИ С ДЕСКРИПТОРАМИ ПРОЦЕССА ---" << endl;

    // Шаг 1: Идентификатор текущего процесса
    DWORD pid = GetCurrentProcessId();
    cout << "1. PID текущего процесса: " << pid << endl;

    // Шаг 2: Псевдодескриптор текущего процесса
    HANDLE hPseudo = GetCurrentProcess();
    cout << "2. Псевдодескриптор: " << hPseudo << endl;

    // Шаг 3: Настоящий дескриптор (через DuplicateHandle)
    HANDLE hReal = NULL;
    DuplicateHandle(
        GetCurrentProcess(), // Исходный процесс (мы сами)
        hPseudo,             // Что копируем (псевдодескриптор)
        GetCurrentProcess(), // Куда копируем (в наш же процесс)
        &hReal,              // Переменная, куда сохранится настоящий дескриптор
        0, FALSE, DUPLICATE_SAME_ACCESS
    );
    cout << "3. Настоящий дескриптор (DuplicateHandle): " << hReal << endl;

    // Шаг 4: Копия дескриптора (через OpenProcess)
    HANDLE hOpened = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pid);
    cout << "4. Копия дескриптора (OpenProcess): " << hOpened << endl;

    // Шаг 5: Закрываем дескриптор от DuplicateHandle
    CloseHandle(hReal);
    cout << "5. Дескриптор от DuplicateHandle закрыт." << endl;

    // Шаг 6: Закрываем дескриптор от OpenProcess
    CloseHandle(hOpened);
    cout << "6. Дескриптор от OpenProcess закрыт." << endl;
    cout << endl;
}

// =====================================================================
// ЗАДАНИЕ 3: Перечисление всех процессов, потоков и модулей
// =====================================================================
void Task3_EnumerateSystem() {
    cout << "--- ЗАДАНИЕ 3: ПЕРЕЧИСЛЕНИЕ СИСТЕМЫ ---" << endl;
    cout << "(Вывод ограничен первыми 5 записями каждого типа, чтобы не засорять консоль)\n" << endl;

    // Делаем снимок (snapshot) всех процессов и потоков в системе
    HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS | TH32CS_SNAPTHREAD, 0);

    if (hSnapshot == INVALID_HANDLE_VALUE) {
        cout << "Ошибка создания снимка системы!" << endl;
        return;
    }

    // 1. ПРОЦЕССЫ
    cout << "[ПРОЦЕССЫ]" << endl;
    PROCESSENTRY32 pe32;
    pe32.dwSize = sizeof(PROCESSENTRY32); // Обязательно указываем размер структуры!
    int count = 0;

    if (Process32First(hSnapshot, &pe32)) {
        do {
            cout << " PID: " << pe32.th32ProcessID << " | Имя: " << pe32.szExeFile << endl;
            count++;
        } while (Process32Next(hSnapshot, &pe32) && count < 5); // Ограничиваем вывод
    }

    // 2. ПОТОКИ
    cout << "\n[ПОТОКИ]" << endl;
    THREADENTRY32 te32;
    te32.dwSize = sizeof(THREADENTRY32);
    count = 0;

    if (Thread32First(hSnapshot, &te32)) {
        do {
            cout << " TID (Поток): " << te32.th32ThreadID << " | Принадлежит PID: " << te32.th32OwnerProcessID << endl;
            count++;
        } while (Thread32Next(hSnapshot, &te32) && count < 5);
    }

    CloseHandle(hSnapshot); // Закрываем снимок процессов и потоков

    // 3. МОДУЛИ (сделаем снимок модулей для текущего процесса, так как перебрать все модули всех процессов очень долго)
    cout << "\n[МОДУЛИ ТЕКУЩЕГО ПРОЦЕССА]" << endl;
    HANDLE hModSnap = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE | TH32CS_SNAPMODULE32, GetCurrentProcessId());

    if (hModSnap != INVALID_HANDLE_VALUE) {
        MODULEENTRY32 me32;
        me32.dwSize = sizeof(MODULEENTRY32);
        count = 0;

        if (Module32First(hModSnap, &me32)) {
            do {
                cout << " Модуль: " << me32.szModule << " | Базовый адрес: " << me32.modBaseAddr << endl;
                count++;
            } while (Module32Next(hModSnap, &me32) && count < 5);
        }
        CloseHandle(hModSnap);
    }
}

// Главная функция, которая просто вызывает все 3 задания по очереди
int main() {
    SetConsoleCP(65001);
    SetConsoleOutputCP(65001); // Чтобы в консоли корректно отображался русский язык

    Task1_Modules();
    Task2_ProcessHandles();
    Task3_EnumerateSystem();

    cout << "\nЛабораторная работа завершена." << endl;
    system("pause"); // Чтобы консоль не закрылась сразу
    return 0;
}