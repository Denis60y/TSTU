#include <iostream>
#include <windows.h> 
#include <string>
#include <chrono>

using namespace std;

int main(int argc, char* argv[]) {

    SetConsoleCP(65001);
    SetConsoleOutputCP(65001);

    if (argc > 1 && string(argv[1]) == "child") {
        int process_id = stoi(argv[2]);

        auto start_time = chrono::high_resolution_clock::now();

        cout << "========================================" << endl;
        cout << " ЗАПУЩЕН ВЕДОМЫЙ ПРОЦЕСС № " << process_id << " (PID: " << GetCurrentProcessId() << ")" << endl;
        cout << "========================================\n" << endl;

        // Разделяем логику в зависимости от номера процесса
        switch (process_id) {
        case 1: {
            cout << "[Задача 1] Вычисление суммы чисел от 1 до 1000..." << endl;
            int sum = 0;
            for (int i = 1; i <= 1000; ++i) {
                sum += i;
            }
            Sleep(1500); // Имитируем работу
            cout << "\nРезультат вычислений: " << sum << endl;
            break;
        }
        case 2: {
            cout << "[Задача 2] Имитация сканирования ресурсов..." << endl;
            for (int i = 1; i <= 5; ++i) {
                cout << "  Сканирование блока " << i * 20 << "%..." << endl;
                Sleep(600); // Пошаговая задержка
            }
            cout << "\nСканирование успешно завершено!" << endl;
            break;
        }
        case 3: {
            cout << "[Задача 3] Вывод графического маркера..." << endl;
            Sleep(1000);
            cout << "\n  /\\_/\\" << endl;
            cout << " ( o.o )  - Процесс 3 отработал!" << endl;
            cout << "  > ^ <" << endl;
            break;
        }
        default: {
            cout << "[Задача] Неизвестная задача." << endl;
            Sleep(1000);
            break;
        }
        }

        auto end_time = chrono::high_resolution_clock::now();
        chrono::duration<double, milli> duration = end_time - start_time;
        DWORD time_spent_ms = (DWORD)duration.count();

        cout << "\n----------------------------------------" << endl;
        cout << "Работа завершена за " << time_spent_ms / 1000.0 << " сек." << endl;
        cout << "Нажмите Enter, чтобы закрыть это окно...";

        cin.get(); 

        return time_spent_ms;
    }

    const int PROCESS_COUNT = 3;
    HANDLE hProcesses[PROCESS_COUNT]; 

    cout << "Ведущий процесс запущен. PID: " << GetCurrentProcessId() << endl;

    for (int i = 0; i < PROCESS_COUNT; ++i) {
        STARTUPINFOA si;          
        PROCESS_INFORMATION pi;  

        ZeroMemory(&si, sizeof(si));
        si.cb = sizeof(si);
        ZeroMemory(&pi, sizeof(pi));

        string cmd = string(argv[0]) + " child " + to_string(i + 1);

        if (CreateProcessA(
            NULL, (LPSTR)cmd.c_str(),
            NULL, NULL, FALSE, CREATE_NEW_CONSOLE, NULL, NULL, 
            &si, &pi
        )) {
            hProcesses[i] = pi.hProcess; 
            CloseHandle(pi.hThread);     
        }
        else {
            cerr << "Ошибка запуска процесса!" << endl;
        }
    }

    WaitForMultipleObjects(PROCESS_COUNT, hProcesses, TRUE, INFINITE);

    cout << "\nВсе ведомые процессы завершены. Сбор данных..." << endl;

    for (int i = 0; i < PROCESS_COUNT; ++i) {
        DWORD exitCode; 

        GetExitCodeProcess(hProcesses[i], &exitCode);

        CloseHandle(hProcesses[i]);

        cout << "-> Ведомый " << i + 1 << " выполнялся: " << exitCode / 1000.0 << " секунд." << endl;
    }

    cout << "Ведущий процесс завершает работу." << endl;
    return 0;
}