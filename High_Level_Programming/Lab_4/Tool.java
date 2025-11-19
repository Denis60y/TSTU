package High_Level_Programming.Lab_4;

class Tool extends Item {
    private int damage;
    private int strength;
    private int power;

    public Tool(String name, String id, int damage, int strength, int power) {
        super(name, id, 1, 1);
        this.damage = damage;
        this.strength = strength;
        this.power = power;
    }

    public void setDamage(int damage) {
        this.damage = damage;
    }

    public int getDamage() {
        return damage;
    }

    public void setStrength(int strength) {
        if (strength > 0){
            this.strength = strength;
        }else{
            System.out.println("Прочность предмета не может быть отрицательной или равной 0");
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
                        + "Наносимый урон: %d\nПрочность предмета: %d\nМощность предмета%b\nЯчейка в инвентаре: %d\n",
                getName(), getId(), getMaxStackSize(), getQuantity(), damage, strength, power, getINdex()+1);
    }

    public void hit(){
        strength -= 1;
    }
}
