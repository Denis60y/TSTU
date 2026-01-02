package High_Level_Programming.Lab_4;

class Tool extends Item {
    private int damage;
    private int maxStrenght;
    private int strength;
    private int power;

    public Tool(String name, String id, int damage, int maxStrenght, int strength, int power) {
        super(name, id, 1, 1);
        this.damage = damage;
        this.maxStrenght = maxStrenght;
        if (strength > 0 && strength <= maxStrenght) {
            this.strength = strength;
        } else {
            System.out.println(
                    "Прочность предмета не может быть отрицательной, равной нулю или выше максимальной возможной прочности");
        }
        this.power = power;
    }

    public Tool(String name, String id, int damage, int maxStrenght, int power) {
        super(name, id, 1, 1);
        this.damage = damage;
        this.maxStrenght = maxStrenght;
        this.strength = maxStrenght;
        this.power = power;
    }

    public void setDamage(int damage) {
        this.damage = damage;
    }

    public int getDamage() {
        return damage;
    }

    public void setMaxStrength(int maxStrenght) {
        this.maxStrenght = maxStrenght;
    }

    public int getMaxStrength() {
        return maxStrenght;
    }

    public void setStrength(int strength) {
        if (strength > 0 && strength <= maxStrenght) {
            this.strength = strength;
        } else {
            System.out.println(
                    "Прочность предмета не может быть отрицательной, равной нулю или выше максимальной возможной прочности");
        }
    }

    public int getStrength() {
        return strength;
    }

    public void setPower(int power) {
        this.power = power;
    }

    public int getPower() {
        return power;
    }

    public void getInfo() {
        System.out.printf(
                "Название предмета: %s\nID предмета: %s\nМаксимальное количество в слоте: %d\nКоличество предметов в яцейке: %d\n"
                        + "Наносимый урон: %d\nПрочность предмета: %d\nМощность предмета%d\nЯчейка в инвентаре: %d\n",
                getName(), getId(), getMaxStackSize(), getQuantity(), damage, strength, power, getIndex() + 1);
    }

    public void hit() {
        strength -= 1;
    }

    public int сalculateSrength() {
        return maxStrenght - strength;
    }
}
