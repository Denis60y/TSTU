#include <windows.h>
#include <iostream>
#include <vector>

using namespace std;

int main() {
    SetConsoleCP(65001);
    SetConsoleOutputCP(65001);

    char computerName[256];
    DWORD size1 = sizeof(computerName);

    if (GetComputerNameA(computerName, &size1)) {
        cout << "Имя компьютера: " << computerName << endl;
    }

    char userName[256];
    DWORD size2 = sizeof(userName);

    if (GetUserNameA(userName, &size2)) {
        cout << "Имя пользователя: " << userName << endl;
    }

    //----------------------------------

    char winPath[MAX_PATH];
    if (GetWindowsDirectoryA(winPath, MAX_PATH)) {
        cout << "\nСистемная папка: " << winPath << endl;
    }

    //----------------------------------

    //DWORD dwVersion = GetVersion();
    //DWORD dwMajorVersion = (DWORD)(LOBYTE(LOWORD(dwVersion)));
    //DWORD dwMinorVersion = (DWORD)(HIBYTE(LOWORD(dwVersion)));
    //cout << "\nВерсия ОС: " << dwMajorVersion << "." << dwMinorVersion << endl;

    char osVersion[256] = { 0 };
    DWORD osSize = sizeof(osVersion);
    RegGetValueA(HKEY_LOCAL_MACHINE, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName", RRF_RT_REG_SZ, NULL, osVersion, &osSize);
    cout << "\nВерсия ОС: " << osVersion << endl;
    
    //----------------------------------

    int width = GetSystemMetrics(SM_CXSCREEN );
    int height = GetSystemMetrics(SM_CYSCREEN);
    cout << "\nРазрешение экрана: " << width << "x" << height << endl;
    cout << "Количество мониторов: " << GetSystemMetrics(SM_CMONITORS) << endl;
    cout << "Мышь подключена: " << (GetSystemMetrics(SM_MOUSEPRESENT) ? "Да" : "Нет") << endl;


    //----------------------------------

    BOOL isBeep;
    SystemParametersInfo(SPI_GETBEEP, 0, &isBeep, 0);
    cout << "\nЗвуковой сигнал (Beep): " << (isBeep ? "Вкл" : "Выкл") << endl;

    UINT delay;
    SystemParametersInfo(SPI_GETKEYBOARDDELAY, 0, &delay, 0);
    cout << "Задержка клавиатуры: " << delay << endl;

    RECT workArea;
    SystemParametersInfo(SPI_GETWORKAREA, 0, &workArea, 0);
    cout << "Рабочая область: " << workArea.right << "x" << workArea.bottom << endl;

    //----------------------------------

    int elements1[] = { COLOR_BTNSHADOW };
    COLORREF colors1[] = { RGB(0, 255, 0) };
    SetSysColors(1, elements1, colors1);
    int elements2[] = { COLOR_INFOTEXT };
    COLORREF colors2[] = { RGB(255, 0, 0) };
    SetSysColors(1, elements2, colors2);
    int elements3[] = { COLOR_CAPTIONTEXT };
    COLORREF colors3[] = { RGB(255, 0, 0) };
    SetSysColors(1, elements3, colors3); 

    COLORREF shadow1 = GetSysColor(COLOR_BTNSHADOW);
    cout << "\nСистемные цвета (COLOR_BTNSHADOW): " << (int)GetRValue(shadow1) << "," << (int)GetGValue(shadow1) << "," << (int)GetBValue(shadow1) << endl;
    COLORREF shadow2 = GetSysColor(COLOR_INFOTEXT);
    cout << "Системные цвета (COLOR_INFOTEXT): " << (int)GetRValue(shadow2) << "," << (int)GetGValue(shadow2) << "," << (int)GetBValue(shadow2) << endl;
    COLORREF shadow3 = GetSysColor(COLOR_CAPTIONTEXT);
    cout << "Системные цвета (COLOR_CAPTIONTEXT): " << (int)GetRValue(shadow3) << "," << (int)GetGValue(shadow3) << "," << (int)GetBValue(shadow3) << endl;

    //----------------------------------

    SYSTEMTIME lt;
    GetLocalTime(&lt);
    printf("\nЛокальное время: %02d:%02d:%02d\n", lt.wHour, lt.wMinute, lt.wSecond);

    TIME_ZONE_INFORMATION tzi;
    GetTimeZoneInformation(&tzi);
    wcout << L"Часовой пояс: " << tzi.StandardName << endl << endl  ;

    DWORD timeAdjustment = 0;
    if (SetSystemTimeAdjustment(timeAdjustment, TRUE)) {
        cout << "Функция SetSystemTimeAdjustment успешно вызвана." << endl;
    }
    else {
        cout << "Доступ ограничен (нужен запуск от Администратора)." << endl;
    }

    //----------------------------------
    
    if (GetAsyncKeyState(VK_SPACE)) {
        cout << "Клавиша spase нажата" << endl;
    }

    int nBuff = GetKeyboardLayoutList(0, NULL);
    vector<HKL> layouts(nBuff);
    GetKeyboardLayoutList(nBuff, &layouts[0]);
    cout << "Количество раскладок клавиатуры: " << nBuff << endl;

    cout << "Время работы системы (мс): " << GetTickCount() << endl;

    if (SetLocaleInfo(LOCALE_USER_DEFAULT, LOCALE_STHOUSAND, L",")) {
        cout << "Разделитель тысяч успешно изменен (локально)." << endl;
    }

    return 0;
}