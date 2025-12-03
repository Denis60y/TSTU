package High_Level_Programming.Lab_5;

class Block extends Item {
    private boolean full;
    private boolean fall;
    private boolean transparency;
    private int strength;

    // Конструкторы
    public Block(String name, String id, int maxStackSize, int quantity, boolean full, boolean fall,
            boolean transparency, int strength) {
        super(name, id, maxStackSize, quantity);
        this.full = full;
        this.fall = fall;
        this.transparency = transparency;
        this.strength = strength;
    }

    public Block(String name, String id, int maxStackSize, boolean full, boolean fall, boolean transparency, int strength) {
        super(name, id, maxStackSize);
        this.full = full;
        this.fall = fall;
        this.transparency = transparency;
        this.strength = strength;
    }

    public Block(String name, String id, boolean full, boolean fall, boolean transparency, int strength) {
        super(name, id);
        this.full = full;
        this.fall = fall;
        this.transparency = transparency;
        this.strength = strength;
    }

    // getter'ы и setter'ы
    public void setFull(boolean full) {
        this.full = full;
    }

    public boolean getFull() {
        return full;
    }

    public void setFall(boolean fall) {
        this.fall = fall;
    }

    public boolean getFall() {
        return fall;
    }

    public void setTransparency(boolean transparency) {
        this.transparency = transparency;
    }

    public boolean getTransparency() {
        return transparency;
    }

    // Функция тотображения всей информации
    public void getInfo() {
        System.out.printf(
                "Название предмета: %s\nID предмета: %s\nМаксимальное количество в слоте: %d\nКоличество предметов в яцейке: %d\n"
                        + "Полный блок: %b\nПадающий блок: %b\nПрозрачный блок: %b\nЯчейка в инвентаре: %d\n",
                getName(), getId(), getMaxStackSize(), getQuantity(), full, fall, transparency, getIndex() + 1);
    }

    // Функция использования предмета
    public void useItem() {
        setQuantity(getQuantity() - 1);
    }

    public boolean checkPossibilityBreaking(Tool tool){
        return tool.getPower()>=strength;
    }
}
