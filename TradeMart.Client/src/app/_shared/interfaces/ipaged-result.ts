import { IPagination } from "./ipagination";

export interface IPagedResult<T> extends IPagination {
    data: T[];
}