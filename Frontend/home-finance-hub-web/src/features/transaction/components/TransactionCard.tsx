import Card from "../../../shared/components/card/Card";
import CardContent from "../../../shared/components/card/CardContent";
import CardSecondaryInformations from "../../../shared/components/card/CardSecondaryInformations";
import CardTitle from "../../../shared/components/card/CardTitle";
import MoneyTag from "../../../shared/components/MoneyTag";
import {
  EExpenseCategoryType,
  expenseCategoryTypeTitle,
} from "../../../shared/types/enums/expense-category-type.enum";
import type { TransactionDTO } from "../types/interfaces/transaction.dto";

export default function TransactionCard({
  description,
  value,
  type,
  categoryDescription,
  personName,
}: TransactionDTO) {
  const valueByCategory =
    type === EExpenseCategoryType.Expenditure ? value * -1 : value;

  return (
    <Card>
      <CardContent>
        <CardTitle title={description ?? "Sem Descrição"} />
        <CardSecondaryInformations>
          <MoneyTag label="Total Balance" value={valueByCategory} />|
          <p>{expenseCategoryTypeTitle[type]}</p>|
          <p>Category: {categoryDescription}</p>|<p>Person: {personName}</p>
        </CardSecondaryInformations>
      </CardContent>
    </Card>
  );
}
