using System;
namespace Chainblock.Common
{
    public static class ExceptionMessages
    {
        public static string InvalideIdMessage = "Id's cannot be zero or negative";
        public static string InvalideAmountMessage = "Amount cannot be zero or negative";
        public static string InvalideSenderUserNameMEssage = "Sender name cannot be empty or white space";
        public static string InvalideReceiverUserNameMEssage = "Receiver name cannot be empty or white space";
        public static string TransactionHasBeenAddedAlready = "Transaction is existing already!";
        public static string NoSuchTransaction = "No such transaction";
        public static string NoTransactionsWithGivenStatus = "No such transactions with given status";
        public static string NoTransactionsWithGivenStatusFromThatSender = "No such transactions with given status from that sender";
        public static string NoTransactionsWithGivenStatusForThatReceiver = "No such transactions with given status from that receiver";
        public static string SenderNotFound = "Sender not found";
        public static string ReceiverNotFound = "Receiver not found";
    }
}
