package High_Level_Programming.Lab_4;

class Block extends Item{
    private boolean full;
    

    public Block(String name, String id, int maxStackSize, int quantitym, boolean full){
        super(name, id, maxStackSize, quantitym);
        this.full = full;
    }

    public Block(String name, String id, int maxStackSize, boolean full){
        super(name, id, maxStackSize);
        this.full = full;
    }

    public Block(String name, String id, boolean full){
        super(name, id);
        this.full = full;
    }
    
    public void setFull(boolean full){this.full = full;}
    public boolean getFull(){return full;}

    public void getInfo(){
        System.out.printf("Название предмета: %s\nID предмета: %s\nМаксимальное количество в слоте: %d\nКоличество предметов в яцейке: %d\n" + //
                        "Полный блок: %b\n", getName(), getId(), getMaxStackSize(), getQuantity(), full);
    }

}
