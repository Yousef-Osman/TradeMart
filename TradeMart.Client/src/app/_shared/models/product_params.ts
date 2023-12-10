import { PaginationParams } from "./pagination_params";

export class ProductParams extends PaginationParams {
    searchValue: string = "";
    brands: string[] = [];
    category: string = "";
    orderBy: string = "";

    constructor() {
        super();
    }
}