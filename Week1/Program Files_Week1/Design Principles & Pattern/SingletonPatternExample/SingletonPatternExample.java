public class SingletonPatternExample {

    // Inner Singleton Logger class
    static class Logger {
        private static Logger instance;

        private Logger() {
            System.out.println("Logger Initialized");
        }

        public static Logger getInstance() {
            if (instance == null) {
                instance = new Logger();
            }
            return instance;
        }

        public void log(String message) {
            System.out.println("Log: " + message);
        }
    }

    // Main method to test singleton behavior
    public static void main(String[] args) {
        Logger logger1 = Logger.getInstance();
        logger1.log("Logging from instance 1");

        Logger logger2 = Logger.getInstance();
        logger2.log("Logging from instance 2");

        System.out.println("Are both instances the same? " + (logger1 == logger2));
    }
}
