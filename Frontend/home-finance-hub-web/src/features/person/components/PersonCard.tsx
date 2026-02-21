import Card from "../../../shared/components/card/Card";
import CardActions from "../../../shared/components/card/CardActions";
import CardContent from "../../../shared/components/card/CardContent";
import CardSecondaryInformations from "../../../shared/components/card/CardSecondaryInformations";
import CardTitle from "../../../shared/components/card/CardTitle";
import { formatCurrency } from "../../../shared/utils/number-helper";
import { EPersonCardAction } from "../types/enums/person-card-action.enum";
import type { PersonItemDTO } from "../types/interfaces/person-item.dto";

interface PersonCardProps extends PersonItemDTO {
  onCardAction: (action: EPersonCardAction, id: number) => void;
}

export default function PersonCard({
  id,
  name,
  age,
  balance,
  totalExpensesByType,
  onCardAction,
}: PersonCardProps) {
  return (
    <Card>
      <CardContent>
        <CardTitle title={name} />
        <CardSecondaryInformations>
          <p>Age: {`${age} years`}</p>|
          <p>Total Balance: {formatCurrency(balance)}</p>|
          <ul className="flex flex-row gap-2">
            {totalExpensesByType.map(({ key, value }, index) => (
              <>
                <li>
                  <span>
                    {key}: {formatCurrency(value)}
                  </span>
                </li>
                <span>
                  {index != totalExpensesByType.length - 1 ? `|` : ""}
                </span>
              </>
            ))}
          </ul>
        </CardSecondaryInformations>
      </CardContent>

      <CardActions>
        <button
          onClick={() => {
            onCardAction(EPersonCardAction.Edit, id);
          }}
          className="cursor-pointer"
        >
          Edit
        </button>
        <button
          onClick={() => {
            onCardAction(EPersonCardAction.Remove, id);
          }}
          className="cursor-pointer"
        >
          Remove
        </button>
      </CardActions>
    </Card>
  );
}
