package High_Level_Programming.Lab_4;

class Player {
    private String name;
    private int HP;
    private int satiety;
    private boolean buff;
    private Item[] items;
    private final int maxSize = 10;
    private int cursor = 0;

    public Player(String name, int HP, int satiety, boolean buff) {
        this.name = name;
        this.HP = HP;
        this.satiety = satiety;
        this.buff = buff;
        this.items = new Item[this.maxSize];
    }








    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
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



    public void setItem(Item item, int number){
        this.items[number] = item;
    }

    public Item[] getItems(){
        return items;
    }

    public void addItem(Item item) {
        if (cursor < maxSize) {
            this.items[cursor] = item;
            item.setIndex(cursor);
            cursor++;
        } else {
            System.out.println("Инвентарь полон!");
        }
    }

    public void getInfoItems(){
        for (int i = 0; i < maxSize; i++){
            if (items[i] != null){
                items[i].getInfo();
                System.out.println("\n");
            }
            else{
                continue;
            }
        }
    }








    public void getInfo() {
        System.out.printf("HP персонажа: %d\nСытость персонажа: %d\nНаличие эффекта: %b\n", HP, satiety, buff);
    }










    public void drinkMilk() {
        this.buff = false;
    }

    public void useFood(Food food) {
        if (food.getQuantity() > 0) {
            food.eaten();
            this.HP += food.getSaturationLevel();
            this.satiety += food.getFoodLevel();
            this.buff = food.getEnchanted();
        } else {
            System.out.println("Не хватает предмета");
        }
    }

    public void drop(Item item) {
        if (item.getQuantity() > 0) {
            item.abandoned();
        } else {
            System.out.println("Не хватает предмета");
        }
    }

    public void setBlock(Block block) {
        if (block.getQuantity() > 0) {
            block.use();
        } else {
            System.out.println("Не хватает предмета");
        }
    }

    public void hit(Tool tool) {
        if (tool.getStrength() > 0) {
            tool.hit();
        } else {
            System.out.println("Предмет сломан");
        }
    }
}
