package High_Level_Programming.Lab_4;

class Food extends Item {
    private int foodLevel; // сытость
    private int saturationLevel;// насыщение
    private boolean enchanted;

    // Конструкторы
    public Food(String name, String id, int maxStackSize, int quantity, int saturationLevel, int foodLevel,
            boolean enchanted) {
        super(name, id, maxStackSize, quantity);
        this.saturationLevel = saturationLevel;
        this.foodLevel = foodLevel;
        this.enchanted = enchanted;
    }

    public Food(String name, String id, int maxStackSize, int quantity, int saturationLevel, int foodLevel) {
        super(name, id, maxStackSize, quantity);
        this.saturationLevel = saturationLevel;
        this.foodLevel = foodLevel;
        this.enchanted = false;
    }

    public Food(String name, String id, int maxStackSize, int saturationLevel, int foodLevel, boolean enchanted) {
        super(name, id, maxStackSize);
        this.saturationLevel = saturationLevel;
        this.foodLevel = foodLevel;
        this.enchanted = enchanted;
    }

    public Food(String name, String id, int maxStackSize, int saturationLevel, int foodLevel) {
        super(name, id, maxStackSize);
        this.saturationLevel = saturationLevel;
        this.foodLevel = foodLevel;
        this.enchanted = false;
    }

    public Food(String name, String id, int saturationLevel, int foodLevel, boolean enchanted) {
        super(name, id);
        this.saturationLevel = saturationLevel;
        this.foodLevel = foodLevel;
        this.enchanted = enchanted;
    }

    public Food(String name, String id, int saturationLevel, int foodLevel) {
        super(name, id);
        this.saturationLevel = saturationLevel;
        this.foodLevel = foodLevel;
        this.enchanted = false;
    }

    // getter'ы и setter'ы
    public void setSaturationLevel(int saturationLevel) {
        this.saturationLevel = saturationLevel;
    }

    public int getSaturationLevel() {
        return saturationLevel;
    }

    public void setFoodLevel(int foodLevel) {
        this.foodLevel = foodLevel;
    }

    public int getFoodLevel() {
        return foodLevel;
    }

    public void setEnchantedl(boolean enchanted) {
        this.enchanted = enchanted;
    }

    public boolean getEnchanted() {
        return enchanted;
    }

    // Функция тотображения всей информации
    public void getInfo() {
        System.out.printf(
                "Название предмета: %s\nID предмета: %s\nМаксимальное количество в слоте: %d\nКоличество предметов в яцейке: %d\n"
                        + "Насыщение еды: %d\nУтоление голода: %d\nЕда с чарами: %d\nЯчейка в инвентаре: %d\n",
                getName(), getId(), getMaxStackSize(), getQuantity(), saturationLevel, foodLevel, enchanted? "да" : "нет",getIndex() + 1);
    }

    // функция поедания предмета
    public void eaten() {
        setQuantity(getQuantity() - 1);
    }
}