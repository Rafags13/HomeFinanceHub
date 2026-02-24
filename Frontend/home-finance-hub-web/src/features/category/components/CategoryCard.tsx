import Card from "../../../shared/components/card/Card";
import CardContent from "../../../shared/components/card/CardContent";
import CardSecondaryInformations from "../../../shared/components/card/CardSecondaryInformations";
import CardTitle from "../../../shared/components/card/CardTitle";
import { expenseCategoryTypeTitle } from "../../../shared/types/enums/expense-category-type.enum";
import type { CategoryDTO } from "../types/interfaces/category.dto";

export default function CategoryCard({
  description,
  purposeType,
}: CategoryDTO) {
  return (
    <Card>
      <CardContent>
        <CardTitle title={description} />
        <CardSecondaryInformations>
          <p>{expenseCategoryTypeTitle[purposeType]}</p>
        </CardSecondaryInformations>
      </CardContent>
    </Card>
  );
}
