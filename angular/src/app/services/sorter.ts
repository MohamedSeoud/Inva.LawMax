export class Sorter {
  sortField: string = '';
  sortDirection: 'asc' | 'desc' = 'asc';

  sort(field: string, direction: 'asc' | 'desc') {
    this.sortField = field;
    this.sortDirection = direction;
  }
}
