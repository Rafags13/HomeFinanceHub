interface Cardtitle {
  title: string;
}

export default function CardTitle({ title }: Cardtitle) {
  return <h5 className="text-xl font-bold">{title}</h5>;
}
