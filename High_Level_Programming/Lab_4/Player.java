package High_Level_Programming.Lab_4;

class Player {
    private int HP;
    private int satiety;
    private boolean buff;
    private Inventory inventory;

    public Player(int HP, int satiety, boolean buff, Inventory inventory) {
        this.HP = HP;
        this.satiety = satiety;
        this.buff = buff;
        this.inventory = inventory;
    }

    public void setHP(int HP) {
        this.HP = HP;
    }

    public int getHP() {
        return HP;
    }

    public void setSatiety(int satiety) {
        this.satiety = satiety;
    }

    public int getSatiety() {
        return satiety;
    }

    public void setBuff(boolean buff) {
        this.buff = buff;
    }

    public boolean getBuff() {
        return buff;
    }

    public void getInfo() {
        System.out.printf("HP персонажа: %d\nСытость персонажа: %d\nНаличие эффекта: %b\n", HP, satiety, buff);
    }

    public void drinkMilk() {
        this.buff = false;
    }

    public void useFood(Food food) {
        food.eaten();
        this.HP += food.getSaturationLevel();
        this.satiety += food.getFoodLevel();
        if (food.getQuantity() == 0){
            inventory.deleteItem(food);
        }
    }

    public void drop(Item item) {
        item.abandoned();
        if (item.getQuantity() == 0){
            inventory.deleteItem(item);
        }
    }

    public void setBlock(Block block) {
        block.use();
        if (block.getQuantity() == 0){
            inventory.deleteItem(block);
        }
    }

    public void hit(Tool tool) {
        tool.hit();
        if (tool.getQuantity() == 0){
            inventory.deleteItem(tool);
        }
    }
}