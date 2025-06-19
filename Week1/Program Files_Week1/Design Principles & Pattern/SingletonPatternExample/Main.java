public class Main {
    public static void main(String[] args) {
        Logger logger1 = Logger.getInstance();
        logger1.log("Logging from instance 1");

        Logger logger2 = Logger.getInstance();
        logger2.log("Logging from instance 2");

        System.out.println("Are both instances the same? " + (logger1 == logger2));
    }
}
