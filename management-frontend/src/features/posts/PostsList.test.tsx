import { screen, render } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';
import { PostsList } from './PostsList';

describe('PositionList', () => {
  it('should render successfully', () => {
    render(<MemoryRouter><PostsList /></MemoryRouter>);
    expect(screen.getByText('Positions')).toBeInTheDocument();
  });
});