export class Paginator {
  page: number = 0;
  pageSize: number = 10;

  setPage(page: number) {
    this.page = page;
  }

  setPageSize(pageSize: number) {
    this.pageSize = pageSize;
  }
}
