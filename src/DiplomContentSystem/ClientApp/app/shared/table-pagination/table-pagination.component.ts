import { Component, ViewChild} from '@angular/core';
import { RtPagedPager } from 'right-angled';

@Component({
    selector: 'table-pagination',
    template: require('./table-pagination.component.html')
})
export class TablePaginationComponent {
    @ViewChild("rtPager")
    private rtPager: any;

    public checkPageNumber(page:number)
    {
        return (page>0)&&(page<=this.rtPager.pager.pageCount);
    }

    public goToPage(page: any) {
        this.rtPager.pager.pageNumber = page;
        this.rtPager.listService.loadData();
    }
}
