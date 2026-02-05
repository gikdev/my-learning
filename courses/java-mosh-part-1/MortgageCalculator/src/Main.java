void main() {
    final int MONTHS_IN_YEAR = 12;
    final int PERCENT = 100;

    var scanner = new Scanner(System.in);

    ask("Principal: ");
    var principal = scanner.nextLong();

    ask("Annual Interest Rate: ");
    var annualInterestRate = scanner.nextFloat();
    var monthlyInterestRate = annualInterestRate / PERCENT / MONTHS_IN_YEAR;

    ask("Period (Years): ");
    var period = scanner.nextInt();
    var paymentsCount = period * MONTHS_IN_YEAR;

    var rawMortgage = calculateRawMortgage(principal, monthlyInterestRate, paymentsCount);
    var formattedMortgage = NumberFormat.getCurrencyInstance().format(rawMortgage);

    System.out.println("Mortgage: " + formattedMortgage);
}

void ask(String question) {
    System.out.print(question);
}

double calculateRawMortgage(long principal, double monthlyInterestRate, int paymentsCount) {
    var part = Math.pow(1 + monthlyInterestRate, paymentsCount);

    return monthlyInterestRate * part / (part - 1) * principal;
}
