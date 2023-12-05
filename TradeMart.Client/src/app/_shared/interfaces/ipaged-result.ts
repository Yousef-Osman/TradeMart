export interface IPagedResult<T> {
    currentPage: number;
    totalPages: number;
    pageSize: number;
    totalCount: number;
    data: T[];
}