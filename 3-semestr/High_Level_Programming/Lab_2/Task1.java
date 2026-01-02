package High_Level_Programming.Lab_2;

public class Task1 {
    public static String distance(int A, int B, int fuel, int volume) {

        int pipa = A * fuel;

        //остатки топлива после первого перлёта
        int remainingFuel = volume - pipa;

        if (remainingFuel < 0)
            return "Топлива не хватит до пункта B!";

        //сколько топлива потребуется для второго перелёта
        int requiredFuel = B * fuel;

        int popa = requiredFuel - remainingFuel;

        if (requiredFuel > volume)
            return "Емкости бака недостаточно для дозаправки!";
        else if (requiredFuel + pipa <= volume)
            return "Дозаправка не требуется!";
        else
            return String.format("Требуемый объем топлива %s литров!", popa);
    }

    public static void main(String[] args) {
        MyFrame app = new MyFrame();
        app.setVisible(true);
    }
}