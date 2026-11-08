#include <iostream>
#include <thread>
#include <mutex>
#include <vector>
#include <chrono>
#include <string>
#include <windows.h>

using namespace std;

mutex screen_mutex;

void drawGraphicObject(const string& name, char symbol, const string& color_code, bool use_sync) {

    auto draw = [&]() {

        cout << color_code;
        cout << "Начинается отрисовка объекта: " << name << "\n";

        for (int i = 0; i < 5; ++i) {
            for (int j = 0; j < 20; ++j) {
                cout << symbol;
                this_thread::sleep_for(std::chrono::milliseconds(2));
            }
            cout << "\n";
        }
        cout << "Отрисовка завершена: " << name << "\033[0m\n\n"; 
        };

    if (use_sync) {
        lock_guard<mutex> lock(screen_mutex);
        draw();
    }
    else {
        draw();
    }
}

void runTest(bool sync) {
    if (sync) {
        cout << "\n=======================================================\n";
        cout << "  ТЕСТ 2: С СИНХРОНИЗАЦИЕЙ (Исключение гонок)  \n";
        cout << "=======================================================\n";
    }
    else {
        cout << "\n=======================================================\n";
        cout << "  ТЕСТ 1: БЕЗ СИНХРОНИЗАЦИИ (Состояние гонки)  \n";
        cout << "=======================================================\n";
    }

    thread t1(drawGraphicObject, "Красная решетка", '#', "\033[31m", sync);
    thread t2(drawGraphicObject, "Зеленая звезда", '*', "\033[32m", sync);
    thread t3(drawGraphicObject, "Синий круг", 'O', "\033[34m", sync);

    t1.join();
    t2.join();
    t3.join();
}

int main() {
    SetConsoleCP(65001);
    SetConsoleOutputCP(65001);

    runTest(false);

    this_thread::sleep_for(std::chrono::seconds(2));

    runTest(true);

    return 0;
}