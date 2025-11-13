package High_Level_Programming.Lab_4;

class Food extends Item{
    private int saturationLevel;
    private int foodLevel;

    public Food(String name, String id, int maxStackSize, int saturationLevel, int foodLevel){
        super(name, id, maxStackSize);
        this.saturationLevel = saturationLevel;
        this.foodLevel = foodLevel;
    }

    public Food(String name, String id, int saturationLevel, int foodLevel){
        super(name, id);
        this.saturationLevel = saturationLevel;
        this.foodLevel = foodLevel;
    }

    public void setSaturationLevel(int saturationLevel){this.saturationLevel = saturationLevel;}
    public int getSaturationLevel(){return saturationLevel;}

    public void setFoodLevel(int foodLevel){this.foodLevel = foodLevel;}
    public int getFoodLevel(){return foodLevel;}

    public void getInfo(){
        System.out.printf("Название предмета: %s\nID предмета: %s\nМаксимальное количество в слоте: %d\nНасыщение еды: %d\nУтоление голода: %d\n", getName(), getId(), getMaxStackSize(),saturationLevel, foodLevel);
    }
}