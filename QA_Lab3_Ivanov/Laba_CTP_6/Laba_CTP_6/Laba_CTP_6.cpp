#include <iostream>
#include <cmath>
using namespace std;

class Angle {
protected:
    int degrees;
    int minutes;
    int seconds;

public:

    Angle(int deg = 0, int min = 0, int sec = 0);

    void Init(int deg, int min, int sec);

    void Read();

    void Display();

    int RoundToDegrees();

    int TotalSeconds();
};

class PlaneAngle : public Angle {
private:
    int z;

public:

    PlaneAngle(int deg = 0, int min = 0, int sec = 0, int z_val = 0);


    int GetZ();

    void SetZ(int z_val);

    int RoundToDegrees();

    PlaneAngle& operator=(Angle& baseAngle);

    void Display();
};


Angle::Angle(int deg, int min, int sec) : degrees(deg), minutes(min), seconds(sec) {}

void Angle::Init(int deg, int min, int sec) {
    degrees = deg;
    minutes = min;
    seconds = sec;
}

void Angle::Read() {
    cout << "Введите градусы: ";
    cin >> degrees;
    cout << "Введите минуты: ";
    cin >> minutes;
    cout << "Введите секунды: ";
    cin >> seconds;
}

void Angle::Display() {
    cout << degrees << "° " << minutes << "' " << seconds << "''" << endl;
}

int Angle::RoundToDegrees() {
    double totalDegrees = degrees + minutes / 60.0 + seconds / 3600.0;
    return round(totalDegrees);
}

int Angle::TotalSeconds() {
    return degrees * 3600 + minutes * 60 + seconds;
}

PlaneAngle::PlaneAngle(int deg, int min, int sec, int z_val) : Angle(deg, min, sec), z(z_val) {}

int PlaneAngle::GetZ() {
    return z;
}

void PlaneAngle::SetZ(int z_val) {
    z = z_val;
}

int PlaneAngle::RoundToDegrees() {
    double totalDegrees = degrees + minutes / 60.0 + seconds / 3600.0 + z;
    return round(totalDegrees);
}

PlaneAngle& PlaneAngle::operator=(Angle& baseAngle) {

    degrees = baseAngle.RoundToDegrees();
    minutes = 0;
    seconds = 0;
    z = baseAngle.TotalSeconds() / 2;
    return *this;
}

void PlaneAngle::Display() {
    Angle::Display();
    cout << "Z: " << z << endl;
}

int main() {
    setlocale(LC_ALL, "rus");

    // Статический объект базового класса
    Angle a1(30, 20, 40);
    cout << "Базовый угол:" << endl;
    a1.Display();
    cout << "Округленный до градусов: " << a1.RoundToDegrees() << endl;
    cout << "Общее количество секунд: " << a1.TotalSeconds() << endl;

    // Статический объект производного класса
    PlaneAngle p1(45, 15, 30, 10);
    cout << "\nПроизводный угол:" << endl;
    p1.Display();
    cout << "Округленный до градусов: " << p1.RoundToDegrees() << endl;

    // Присваивание объекта базового класса объекту производного класса
    PlaneAngle p2;
    p2 = a1;       // Присваивание
    cout << "\nПроизводный угол после присваивания:" << endl;
    p2.Display();

    return 0;
}