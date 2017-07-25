export function removeArrayItem(items, index) {
  return [
    ...items.slice(0, index),
    ...items.slice(index + 1),
  ];
}
