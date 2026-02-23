import Card from "../../../shared/components/card/Card";
import CardContent from "../../../shared/components/card/CardContent";
import CardSecondaryInformations from "../../../shared/components/card/CardSecondaryInformations";
import CardTitle from "../../../shared/components/card/CardTitle";
import { expenseCategoryTypeTitle } from "../../../shared/types/enums/expense-category-type.enum";
import { formatCurrency } from "../../../shared/utils/number-helper";
import type { TransactionDTO } from "../types/interfaces/transaction.dto";

export default function TransactionCard({
  description,
  value,
  type,
  categoryDescription,
  personName,
}: TransactionDTO) {
  return (
    <Card>
      <CardContent>
        <CardTitle title={description ?? "Sem Descrição"} />
        <CardSecondaryInformations>
          <p>Total Balance: {formatCurrency(value)}</p>|
          <p>{expenseCategoryTypeTitle[type]}</p>|
          <p>Category: {categoryDescription}</p>|<p>Person: {personName}</p>
        </CardSecondaryInformations>
      </CardContent>
    </Card>
  );
}
