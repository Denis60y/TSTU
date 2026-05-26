public class task1 {
    public static void main(String[] args) {
        // Получение имени компьютера
        String computerName = System.getenv("COMPUTERNAME");

        
        // Получение имени пользователя
        String userName = System.getProperty("user.name");

        System.out.println("Имя компьютера: " + computerName);
        System.out.println("Имя пользователя: " + userName);
    }
}