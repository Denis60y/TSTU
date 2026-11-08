#include <iostream>
#include <windows.h>

using namespace std;

void drawDiagram(DWORD percent) {
    cout << "[";
    int bars = percent / 5; 
    for (int i = 0; i < 20; i++) {
        if (i < bars) {
            cout << "#"; 
        }
        else {
            cout << " "; 
        }
    }
    cout << "] " << percent << "%" << endl;
}

void showMemoryStatus() {
    MEMORYSTATUSEX memInfo;
    memInfo.dwLength = sizeof(memInfo); 

    if (GlobalMemoryStatusEx(&memInfo)) {
        cout << "=== СТАТУС ПАМЯТИ ===" << endl;
        cout << "Использование памяти: ";
        drawDiagram(memInfo.dwMemoryLoad);

        long long toMB = 1024 * 1024;

        cout << "Всего физической памяти: " << memInfo.ullTotalPhys / toMB << " MB" << endl;
        cout << "Свободно физической памяти: " << memInfo.ullAvailPhys / toMB << " MB" << endl;
        cout << "Всего виртуальной памяти: " << memInfo.ullTotalVirtual / toMB << " MB" << endl;
        cout << "Свободно виртуальной памяти: " << memInfo.ullAvailVirtual / toMB << " MB" << endl;
    }
    else {
        cout << "Ошибка получения данных о памяти." << endl;
    }
}

void showMemoryMap() {
    cout << "\n=== КАРТА ВИРТУАЛЬНОЙ ПАМЯТИ ПРОЦЕССА ===" << endl;

    HANDLE hProcess = GetCurrentProcess();


    SYSTEM_INFO sysInfo;
    GetSystemInfo(&sysInfo);

    unsigned char* address = (unsigned char*)sysInfo.lpMinimumApplicationAddress;
    unsigned char* maxAddress = (unsigned char*)sysInfo.lpMaximumApplicationAddress;

    MEMORY_BASIC_INFORMATION memBuffer;

    cout << "Адрес начала\tРазмер (КБ)\tСостояние" << endl;
    cout << "--------------------------------------------------" << endl;

    while (address < maxAddress) {
        size_t result = VirtualQueryEx(hProcess, address, &memBuffer, sizeof(memBuffer));

        if (result == 0) {
            break; 
        }

        cout << (void*)address << "\t";
        cout << memBuffer.RegionSize / 1024 << "\t\t";

        if (memBuffer.State == MEM_COMMIT) {
            cout << "Выделена (Committed)";
        }
        else if (memBuffer.State == MEM_RESERVE) {
            cout << "Зарезервирована (Reserved)";
        }
        else if (memBuffer.State == MEM_FREE) {
            cout << "Свободна (Free)";
        }
        cout << endl;

        address += memBuffer.RegionSize;
    }
}

int main() {
    SetConsoleCP(65001);
    SetConsoleOutputCP(65001);

    showMemoryStatus();
    showMemoryMap();

    system("pause");
    return 0;
}